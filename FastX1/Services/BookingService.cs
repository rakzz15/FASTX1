using FastX1.Data;
using FastX1.Models;
using FastX1.Repositories.Interfaces;
using FastX1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastX1.Services
{
        public class BookingService : IBookingService
        {
            private readonly IBookingRepository _bookingRepo;
            private readonly FastXDbContext _context; // still needed for related data like Seat, Schedule

            public BookingService(IBookingRepository bookingRepo, FastXDbContext context)
            {
                _bookingRepo = bookingRepo;
                _context = context;
            }

            public async Task<List<Seat>> GetAvailableSeatsAsync(int scheduleId)
            {
                return await _context.Seats
                    .Where(s => s.ScheduleID == scheduleId && !s.IsBooked)
                    .ToListAsync();
            }

            public async Task<Booking> CreateBookingAsync(int userId, int scheduleId, List<string> seatNumbers)
            {
                var availableSeats = await GetAvailableSeatsAsync(scheduleId);
                var selectedSeats = availableSeats
                    .Where(s => seatNumbers.Contains(s.SeatNumber))
                    .ToList();

                if (selectedSeats.Count != seatNumbers.Count)
                    throw new Exception("One or more selected seats are already booked.");

                var farePerSeat = await _context.BusSchedules
                    .Where(s => s.ScheduleID == scheduleId)
                    .Include(s => s.Route)
                    .Select(s => s.Route.Fare)
                    .FirstOrDefaultAsync();

                var booking = new Booking
                {
                    UserID = userId,
                    ScheduleID = scheduleId,
                    BookingDate = DateTime.Now,
                    TotalAmount = farePerSeat * selectedSeats.Count,
                    Status = "CONFIRMED",
                    BookingSeats = selectedSeats.Select(seat => new BookingSeat
                    {
                        SeatID = seat.SeatID
                    }).ToList()
                };

                foreach (var seat in selectedSeats)
                {
                    seat.IsBooked = true;
                }

                // Save via repository
                var addedBooking = await _bookingRepo.AddAsync(booking);

                return addedBooking;
            }

            public async Task<bool> CancelBookingAsync(int bookingId, string reason)
            {
                var booking = await _bookingRepo.GetByIdAsync(bookingId);

                if (booking == null || booking.Status == "CANCELLED")
                    return false;

                // Free up the booked seats
                foreach (var bookingSeat in booking.BookingSeats)
                {
                    bookingSeat.Seat.IsBooked = false;
                }

                var cancellation = new CancellationLog
                {
                    BookingID = booking.BookingID,
                    CancelReason = reason,
                    CancelDate = DateTime.Now,
                    RefundAmount = booking.TotalAmount
                };

                // Save cancellation and update booking
                _context.CancellationLogs.Add(cancellation);
                return await _bookingRepo.CancelAsync(booking);
            }
        }
    }



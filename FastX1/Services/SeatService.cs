using FastX1.Data;
using FastX1.Models;
using FastX1.Repositories.Interfaces;
using FastX1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastX1.Services
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _seatRepository;

        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<List<Seat>> GetSeatsByScheduleIdAsync(int scheduleId)
        {
            var seats = await _seatRepository.GetByScheduleIdAsync(scheduleId);
            return seats.ToList();
        }

        public async Task<List<Seat>> GetAvailableSeatsAsync(int scheduleId)
        {
            var seats = await _seatRepository.GetAvailableSeatsAsync(scheduleId);
            return seats.ToList();
        }

        public async Task<bool> MarkSeatAsBookedAsync(int seatId)
        {
            var seat = await _seatRepository.GetByIdAsync(seatId);
            if (seat == null || seat.IsBooked)
                return false;

            seat.IsBooked = true;
            await _seatRepository.UpdateAsync(seat);
            return true;
        }

        public async Task<bool> MarkSeatAsAvailableAsync(int seatId)
        {
            var seat = await _seatRepository.GetByIdAsync(seatId);
            if (seat == null || !seat.IsBooked)
                return false;

            seat.IsBooked = false;
            await _seatRepository.UpdateAsync(seat);
            return true;
        }
    }
}

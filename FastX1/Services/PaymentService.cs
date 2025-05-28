using FastX1.Data;
using FastX1.Models;
using FastX1.Repositories.Interfaces;
using FastX1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastX1.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly FastXDbContext _context;

        public PaymentService(IPaymentRepository paymentRepository, FastXDbContext context)
        {
            _paymentRepository = paymentRepository;
            _context = context;
        }

        public async Task<Payment> AddPaymentAsync(Payment payment)
        {
            var bookingExists = await _context.Bookings.AnyAsync(b => b.BookingID == payment.BookingID);
            if (!bookingExists)
                throw new Exception("Booking does not exist.");

            payment.PaymentDate = DateTime.Now;
            return await _paymentRepository.AddAsync(payment);
        }

        public async Task<Payment> GetPaymentByBookingIdAsync(int bookingId)
        {
            return await _paymentRepository.GetByBookingIdAsync(bookingId);
        }
    }
}
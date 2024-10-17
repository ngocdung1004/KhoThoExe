using AutoMapper;
using KhoThoExe.DTOs;
using KhoThoExe.Models;

namespace KhoThoExe.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Map từ Model sang DTO
            CreateMap<User, UserDto>();
            CreateMap<Worker, WorkerDto>();
            CreateMap<JobType, JobTypeDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Payment, PaymentDto>();
            CreateMap<Subscription, SubscriptionDto>();
            CreateMap<WorkerJobType, WorkerJobTypeDto>();

            // Map ngược lại từ DTO sang Model (nếu cần)
            CreateMap<UserDto, User>();
            CreateMap<WorkerDto, Worker>();
            CreateMap<JobTypeDto, JobType>();
            CreateMap<ReviewDto, Review>();
            CreateMap<PaymentDto, Payment>();
            CreateMap<SubscriptionDto, Subscription>();
            CreateMap<WorkerJobTypeDto, WorkerJobType>();
        }
    }
}

using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DtoLayer.Dtos.AnnouncementDto;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EFCommentDal>();

            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDal, EFDestinationDal>();

            services.AddScoped<IAbout2Service, About2Manager>();
            services.AddScoped<IAbout2Dal, EFAbout2Dal>();

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EFAboutDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EFContactDal>();

            services.AddScoped<IFeatureService, FeatureManager>();
            services.AddScoped<IFeatureDal, EFFeatureDal>();

            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EFGuideDal>();

            services.AddScoped<INewsLetterService, NewsLetterManager>();
            services.AddScoped<INewsLetterDal, EFNewsLetterDal>();

            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EFReservationDal>();

            services.AddScoped<ISubAboutService, SubAboutManager>();
            services.AddScoped<ISubAboutDal, EFSubAboutDal>();

            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialDal, EFTestimonialDal>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal, EFUserDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EFAnnouncementDal>();
        }

        public static void CustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AnnouncementAddDto>, AnnouncementValidator>();
        }
    }
}

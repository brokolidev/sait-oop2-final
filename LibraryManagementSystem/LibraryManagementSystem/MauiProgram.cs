﻿using Microsoft.Extensions.Logging;
using LibraryManagementSystem.Persistence;
using LibraryManagementSystem.Pages;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;

namespace LibraryManagementSystem
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            //Solution found here: https://youtu.be/sS1xej5YoLs?si=SL5NwkWxUoBW7FRK&t=471
            builder.Services.AddDbContext<LMSDbContext>();

            //this will need to be replaced by all of the pages that use the database
            builder.Services.AddTransient<MainPage>();

            var dbContext = new LMSDbContext();
            dbContext.Database.EnsureCreated();
            dbContext.Dispose();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

﻿using ElderlyCareSupport.Server.Repositories.Interfaces;
using ElderlyCareSupport.Server.Services.Interfaces;
using ElderlyCareSupport.Server.ViewModels;

namespace ElderlyCareSupport.Server.Services.Implementations
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository registrationRepository;
        private readonly ILogger<RegistrationService> logger;
        public RegistrationService(IRegistrationRepository registrationRepository, ILogger<RegistrationService> logger)
        {
            this.registrationRepository = registrationRepository;
            this.logger = logger;
        }

        public async Task<bool> RegisterUser(RegistrationViewModel registrationViewModel)
        {
            try
            {
                var result = await registrationRepository.RegisterUser(registrationViewModel);

                if (result)
                {
                    logger.LogInformation("Started Registering User Details from {ClassName}\nAt Method: {MethodName}", nameof(RegistrationService), nameof(RegisterUser));
                    return result;
                }
                else
                {
                    logger.LogWarning("Can't Register User Details from {ClassName}\nAt Method: {MethodName}", nameof(RegistrationService), nameof(RegisterUser));
                    return false;
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error Registering User Details from {ClassName}\nAt Method: {MethodName}", nameof(RegistrationService), nameof(RegisterUser));
                return false;
            }
        }
    }
}

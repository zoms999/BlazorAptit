﻿using BlazorAptit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAptit.Services
{
public interface IMailService
{
    Task SendEmailAsync(MailRequest mailRequest);
    Task SendWelcomeEmailAsync(WelcomeRequest request);
}
}

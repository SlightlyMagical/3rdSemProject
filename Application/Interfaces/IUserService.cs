﻿using Application.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        List<Coach> GetAllCoaches();
        bool UpdateWorkingHours(WorkingHoursDTO dto);
    }
}

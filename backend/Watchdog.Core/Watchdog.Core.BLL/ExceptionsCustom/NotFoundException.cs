﻿using System;

namespace Watchdog.Core.BLL.ExceptionsCustom
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string name): base($"{name} not found")
        {

        }

        public NotFoundException(string name, int id): base($"Entity {name} with id ({id}) was not found.")
        {

        }
    }
}
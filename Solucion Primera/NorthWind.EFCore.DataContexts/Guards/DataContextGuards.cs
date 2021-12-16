﻿using Microsoft.EntityFrameworkCore;
using NorthWind.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.EFCore.DataContexts.Guards
{
    /// <summary>
    /// Capturar las excepciones
    /// </summary>
    public class DataContextGuards
    {
        /// <summary>
        /// Guardar los cambios
        /// </summary>
        public static void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new UpdateException(ex.InnerException?.Message ?? ex.Message, 
                    ex.Entries.Select(e=>e.Entity.GetType().Name).ToList());
            }
            catch (Exception ex)
            {
                throw new GeneralException(ex.Message);
            }
        }
    }
}

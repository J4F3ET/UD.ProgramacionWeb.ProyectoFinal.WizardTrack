﻿using JWT.Algorithms;
using JWT.Serializers;
using JWT;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using System.Security.Cryptography;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Exceptions;
using JWT.Builder;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.ServicesControllers;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO.ServicesHTTP;
using Azure;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Services
{
    public class ServiceUsuario: IServiceUser
    {
        private readonly Seguridad seguridad = new();

        public async Task<UserWizardtrack> SaveUser(SignUpServiceDTO user)
        {
            try
            {
                (string hash, byte[] salt) = seguridad.HashPassword(user.password);
                if (user != null)
                {
                    using WizardtrackContext context = new();
                    {
                        UserWizardtrack newUser = new(user.name, user.email, hash, salt);
                        context.UserWizardtracks.Add(newUser);
                        await context.SaveChangesAsync();
                        return newUser;
                    }
                }
                else throw new ExceptionEmpyObject("usuario vacio");

            }
            catch (ExceptionEmpyObject ex)
            {
                throw ex;
            }
            catch (Exception ex) {
                throw new Exception("Fallo al ejecutar la sentecia", ex);
            } 
        }

        public Task<UserWizardtrack> UpdateUser(UserWizardtrack user)
        {
            throw new NotImplementedException();
        }

        public Task<UserWizardtrack> DeleteUser(UserWizardtrack? user, string id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserWizardtrack>? SelectUser(string? name, string email)
        {
            try {
                UserWizardtrack? user = null;
                using WizardtrackContext context = new();
                {
                    if (name == null) { user = await context.UserWizardtracks.FirstOrDefaultAsync(u => u.Email == email); }
                    else { user = await context.UserWizardtracks.FirstOrDefaultAsync(u => u.Name == name && u.Email == email); }
                    return user;
                }
            }
            catch (Exception ex) { 
                throw new Exception("Fallo la consulta",ex);
            }
        }
    }
}
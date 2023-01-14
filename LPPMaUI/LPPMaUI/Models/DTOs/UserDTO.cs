using LPPMaUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPPMaUI.Models.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; } = default!;
        public string? Identifiant { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public string Firstname { get; set; } = default!;
        public string Lastname { get; set; } = default!;
        public string Pseudo { get; set; } = default!;
        public string Email { get; set; } = default!;
        public int Karma { get; set; }
        //public string? PictureURL { get; set; }
        //public string? PictureId { get; set; }
        public bool IsAdmin { get; set; } = default!;
        public int Report { get; set; }
        public int Followers { get; set; }
        public int Followeds { get; set; }

        public UserDTO() { }

        public UserDTO(UserEntity user)
        {
            Id = user.Id;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Pseudo = user.Pseudo;
            Email = user.Email;
            Karma = user.Karma;
            IsAdmin = user.IsAdmin;
            Report = user.Report;
        }

        public UserEntity ToUser()
        {
            return new UserEntity()
            {
                Id = Id,
                Firstname = Firstname,
                Lastname = Lastname,
                Pseudo = Pseudo,
                Email = Email,
                Karma = Karma,
                IsAdmin = IsAdmin,
                Report = Report,
            };
        }
    }
}

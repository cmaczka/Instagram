﻿using Instagram.Models;

namespace Instagram.DTO
{
    public class LoginResponseDto
    {
        public User? User { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public bool IsValidPassword { get; set; }
    }
}

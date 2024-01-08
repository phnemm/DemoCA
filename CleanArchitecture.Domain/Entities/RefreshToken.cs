﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string? Token { get; set; }
        public DateTime ExpiresTime { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
    }
}

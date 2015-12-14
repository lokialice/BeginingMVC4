﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HaveYouSeenMe.Models
{
    public class MessageModel
    {
        [Required(ErrorMessage = "Please type your name")]
        [StringLength(150,ErrorMessage = "You can only add up to 150 characters")]
        [FullName(ErrorMessage = "Please type your full name")]
        public string From { get; set; }

        [Required(ErrorMessage = "Please type your email address")]
        [StringLength(150,ErrorMessage = "You can only add up to 150 characters")]
        [EmailAddress(ErrorMessage = "We don't recognize this as a valid email address")]
        public string Email { get; set; }

        [StringLength(150,ErrorMessage = "You can only add up to 150 characters")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please type your message")]
        [StringLength(150,ErrorMessage = "You can only add up to 150 characters")]
        public string Message { get; set; }
    }
}
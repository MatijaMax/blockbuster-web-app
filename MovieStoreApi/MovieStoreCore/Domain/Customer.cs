﻿using MovieStoreCore.Domain.Enums;

namespace MovieStoreCore.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public Status Status { get; set; }
        public Role Role { get; set; }
        public DateTime? StatusExpirationDate { get; set; }
        public IList<PurchasedMovie> PurchasedMovies { get; } = new List<PurchasedMovie>();
    }
}

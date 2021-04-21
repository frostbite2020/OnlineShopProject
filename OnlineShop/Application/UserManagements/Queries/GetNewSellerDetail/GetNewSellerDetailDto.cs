using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserManagements.Queries.GetNewSellerDetail
{
    public class GetNewSellerDetailDto
    {
        public int Id { get; set; }
        public int UserPropertyId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string NPWP { get; set; }
        public string IdCardNumber { get; set; }
        public string StoreName { get; set; }
        public string StoreDescription { get; set; }
        public string StoreAddress { get; set; }
        public string StoreContact { get; set; }
        public string DateRequest { get; set; }
    }
}

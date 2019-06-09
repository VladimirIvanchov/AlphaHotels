using System;
using System.Collections.Generic;
using System.Text;
using AlphaHotel.Data;
using AlphaHotel.Models;
using Microsoft.EntityFrameworkCore;

namespace AlphaHotel.Tests.TestUtils
{
    public class AccountTestUtils
    {
        public static DbContextOptions GetOptions(string DbName)
        {
            return new DbContextOptionsBuilder()
                .UseInMemoryDatabase(DbName)
                .Options;
        }
    }
}

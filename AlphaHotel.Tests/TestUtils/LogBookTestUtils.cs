using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AlphaHotel.Data;
using AlphaHotel.Models;

namespace AlphaHotel.Tests.TestUtils
{
    public class LogBookTestUtils
    {
        public static DbContextOptions GetOptions(string DbName)
        {
            return new DbContextOptionsBuilder()
                .UseInMemoryDatabase(DbName)
                .Options;
        }
    }
}

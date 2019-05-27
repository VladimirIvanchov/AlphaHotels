using AlphaHotel.Data;
using AlphaHotel.DTOs;
using AlphaHotel.Models;
using AlphaHotel.Services.Contracts;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaHotel.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AlphaHotelDbContext context;

        public CategoryService(AlphaHotelDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<CategoryDTO>> ListAllCategoriesAsync()
        {
            var categories = await this.context.Categories
                .ProjectTo<CategoryDTO>()
                .ToListAsync();

            return categories;
        }

        public async Task<int> AddCategory(string categoryName)
        {
            var category = await this.context.Categories
                .FirstOrDefaultAsync(c => c.Name == categoryName);

            if (category != null)
            {
                throw new ArgumentException($"Category: {categoryName} already exist!");
            }

            var newCategory = new Category
            {
                Name = categoryName
            };

            this.context.Add(newCategory);
            return await this.context.SaveChangesAsync();
        }
    }
}

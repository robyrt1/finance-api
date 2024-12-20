﻿using finance.api.src.category.application.usecases.v1;
using finance.api.src.category.application.usecases.v1.dtos;
using finance.api.src.category.domain.port.repository;
using finance.api.src.category.domain.port.usecases.createCategory.v1;
using finance.api.src.category.domain.port.usecases.createSubCategory.v1;
using finance.api.src.category.domain.port.usecases.getAllCategory;
using finance.api.src.category.domain.port.usecases.getAllSubCategory.v1;
using finance.api.src.category.domain.port.usecases.updateCategory.v1;
using finance.api.src.category.domain.validator;
using finance.api.src.category.infra.repository;
using FluentValidation;

namespace finance.api.src.category.infra.module
{
    public static class CategoryModule
    {
        public static void AddCategoryServices(this IServiceCollection services)
        {
            services.AddTransient<ICategoryRepositoryPort, CategoryRepository>();
            services.AddTransient<ISubCategoryRepositoryPort, SubCategoryRepository>();

            /*USE-CASES*/
            services.AddTransient<IGetAllCategoryUseCasePort, FindAllCategoryUseCaseV1>();
            services.AddTransient<ICreatecategoryUseCasePort, CreateCategoryUseCaseV1>();
            services.AddTransient<IUpdateCategoryUseCasePort, UpdateCategoryUseCaseV1>();
            services.AddTransient<ICreateSubCategoryUseCaseV1, CreateSubCategoryUseCaseV1>();
            services.AddTransient<IGetAllSubCategoryUseCaseV1, GetAllSubCategoryUseCaseV1>();
            /*VALIDATOR*/
            services.AddTransient<IValidator<CreateCategoryDto>, ValidateCreateCategory>();
            services.AddTransient<IValidator<UpdateCategoryDto>, ValidateUpdateCategory>();
            services.AddTransient<IValidator<CreateSubCategoryDto>, ValidateCreateSubCatetory>();

        }
    }
}

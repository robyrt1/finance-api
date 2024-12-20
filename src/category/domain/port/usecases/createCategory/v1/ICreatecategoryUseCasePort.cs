﻿using finance.api.src.category.domain.entity;
using finance.api.src.category.domain.port.usecases.createCategory.v1.type;

namespace finance.api.src.category.domain.port.usecases.createCategory.v1
{
    public interface ICreatecategoryUseCasePort
    {
        Task<Category> execute(ICreateCategoryInput input);
    }
}

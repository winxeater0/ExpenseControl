using ExpenseControl.Application.Common.Interfaces;
using ExpenseControl.Domain.Entities;

namespace ExpenseControl.Application.Categories.Create;

public class CreateCategoryHandler
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryHandler(
        ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Guid> Handle(CreateCategoryRequest request)
    {
        var category = new Category(
            request.Description,
            request.Purpose);

        await _categoryRepository.AddAsync(category);

        return category.Id;
    }
}


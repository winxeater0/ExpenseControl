using ExpenseControl.Application.Common.Interfaces;
using ExpenseControl.Application.People.List;

namespace ExpenseControl.Application.Categories.List;

public class ListCategoryHandler
{
    private readonly ICategoryRepository _categoryRepository;

    public ListCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryDto>> Handle()
    {
        var categories = await _categoryRepository.ListAsync();

        return categories.Select(p =>
            new CategoryDto(
                p.Id,
                p.Description,
                p.Purpose));
    }
}


using Library.Models;

namespace Library.ViewModels
{
    public record StudentViewModel : CommonViewModel
    {
        public Student[] Students { get; set; } = Array.Empty<Student>();
    }
}

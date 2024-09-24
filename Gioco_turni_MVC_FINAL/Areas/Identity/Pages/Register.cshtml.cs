using Gioco_turni_MVC_FINAL.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Gioco_turni_MVC_FINAL.Areas.Identity.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserRepository _userRepository;

        public RegisterModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        {

        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    var (result, conn) = _userRepository.OpenConnectionDb();

        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        _userRepository.ClosingConnection(conn);
        //    }

        //}
    }
}

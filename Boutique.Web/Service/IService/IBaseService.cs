using Boutique.Web.Models;

namespace Boutique.Web.Service.IService;

public interface IBaseService
{
   Task <ResponseDto?> SendAsync(ResponseDto responseDto);
}

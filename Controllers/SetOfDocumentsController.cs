using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using WinSoft.Data;
using WinSoft.Models;
using WinSoft.Services;

namespace WinSoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetOfDocumentsController : ControllerBase
    {
        private readonly SetOfDocumentsServices _setService;
        private readonly ApplicationDbContext _context;

        public SetOfDocumentsController(SetOfDocumentsServices setOfDocumentsServices,
            ApplicationDbContext context)
        {
            _setService = setOfDocumentsServices;
            _context = context;
        }



        //получение списка поданых пользователями комплектов документов
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        [Route("getSetOfDocuments")]
        public async Task<List<SetOfDocuments>> GetSetOfDocuments()
        {
            return await _setService.GetSetOfDocuments();
        }


        //изменение статуса комплекта документов
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut]
        [Route("changeStatusSetOfDocuments")]
        public async Task<IActionResult> ChangeStatusSetOfDocuments(int setOfDocumentsId, Status status)
        {
            var statusOperation = await _setService.ChangeStatusSetOfDocuments(setOfDocumentsId, status);
            if (statusOperation == StatusOperation.Success)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Status of the set of documents has not been changed");
            }
        }



        /// <summary>
        /// создание пользователем комплекта документов
        /// </summary>
        /// <param name="setOfDocumeModel"></param>
        /// <returns></returns>
        /// <remarks>Sample request:
        /// {
        ///    "SetOfDocumentsTemplateId" : 6,
        ///    "Documents" : [
        ///        {
        ///            "DocumentTemplateId" : 2,
        ///            "Fields": [
        ///                {
        ///                    "FieldOfDocumentTemplateId" : 2,
        ///                    "Value" : "input value of field"
        ///    }
        ///            ]
        ///    },
        ///        {
        ///    "DocumentTemplateId" : 3,
        ///            "Fields": [
        ///                {
        ///        "FieldOfDocumentTemplateId" : 2,
        ///                    "Value" : "input value of field"
        ///    }
        ///            ]
        ///    }
        ///    ]
        ///    }
        /// </remarks>
        [Authorize(Roles = UserRoles.User)]
        [HttpPost]
        [Route("createSetOfDocuments")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSetOfDocuments(SetOfDocumentsModel setOfDocumeModel)
        {
            var userId = GetCurrentUser(_context)?.Id;
            var statusOperation = await _setService.CreateSetOfDocuments(setOfDocumeModel, userId);

            if (statusOperation == StatusOperation.Success)
            {
                return CreatedAtAction(nameof(CreateSetOfDocuments), statusOperation); //тут нужно вернуть DTO, но лень писать класс
            }
            else
            {
                return BadRequest("Set of documents has not been saved");
            }
        }



        /// <summary>
        /// проверка пользователем статуса комплекта документов
        /// </summary>
        /// <param name="setOfDocumentsId"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = UserRoles.User)]
        [HttpGet]
        [Route("checkStatus")]
        public async Task<ActionResult<Status>> CheckStatusSetOfDocuments([FromQuery] int setOfDocumentsId)
        {
            try
            {
                var userId = GetCurrentUser(_context)?.Id;
                var status =  await _setService.CheckStatusSetOfDocuments(setOfDocumentsId, userId);
                return status!;
            }
            catch (Exception)
            {
                return BadRequest("Set of documents not found");
            }

        }



        private ApplicationUser? GetCurrentUser(ApplicationDbContext context)
        {
            var identity = User.Identity as ClaimsIdentity;
            return context.Users.FirstOrDefault(u => u.UserName == identity.Name);
        }
    }
}

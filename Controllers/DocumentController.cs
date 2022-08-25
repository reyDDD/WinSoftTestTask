using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using WinSoft.Models;
using WinSoft.Services;

namespace WinSoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly DocumentService _documentService;

        public DocumentController(DocumentService documentService)
        {
            _documentService = documentService;
        }


        /// <summary>
        /// создание нового типа документа, который может заполнять и подавать пользователь
        /// </summary>
        /// <param name="newDocumentTemplate"></param>
        /// <returns></returns>
        /// <remarks>Sample request:
        /// {
        /// "name": "PASSPORT",
        /// "fields": [
        /// {
        /// "name": "FIO",
        /// "IsEmpty": false,
        /// "ValueType": 2
        /// },
        /// {
        /// "name": "Serial number",
        /// "IsEmpty": false,
        /// "ValueType": 1
        /// }
        /// ]}
        /// </remarks>
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        [Route("createNewDocument")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateNewDocumentType([FromBody] DocumentModel newDocumentTemplate)
        {
            var doc = await _documentService.CreateDocumentTemplate(newDocumentTemplate);

            return CreatedAtAction(nameof(CreateNewDocumentType), doc);
        }

        /// <summary>
        /// создание нового комплекта документов, который может заполнять и подавать пользователь
        /// </summary>
        /// <param name="newSetOfDocumentTemplate"></param>
        /// <returns>Созданный пакет документов с идентификаторами используемых документов</returns>
        /// <remarks>Sample request:
        /// {
        ///   "name": "name of document set",
        ///   "documenttemplateids": [2,3]
        /// }
        /// </remarks>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        [Route("createNewSetOfDocuments")]
        public async Task<IActionResult> CreateNewSetOfDocuments([FromBody] SetOfDocumentsTemplateModel newSetOfDocumentTemplate)
        {
            var setOfDoc = await _documentService.CreateNewSetOfDocumentsTemplate(newSetOfDocumentTemplate);

            return CreatedAtAction(nameof(CreateNewSetOfDocuments), setOfDoc);
        }
    }
}


using api_guardian.Dtos.Module;
using api_guardian.Dtos.Response;
using api_guardian.Module.ConsolidadosModule;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace api_guardian.Controllers
{
    [ApiController]
    [Route("api/consolidado")]
    public class ReportConsolidadoController : ControllerBase
    {
        private readonly ILogger<ReportConsolidadoController> _logger;
        private readonly ConsolidadosReportsModule _consolidadosReportsModule;
        private readonly ConsolidadoModule _consolidadoModule;

        public ReportConsolidadoController(
            ILogger<ReportConsolidadoController> logger,
            ConsolidadosReportsModule consolidadosReports,
            ConsolidadoModule consolidadoModule
        )
        {
            this._logger = logger;
            this._consolidadosReportsModule = consolidadosReports;
            this._consolidadoModule = consolidadoModule;
        }

        [HttpGet]
        public async Task<ResponseDto<ConsolidadoModuleDto>> Index()
        {
            var resultado = await this._consolidadoModule.Index();
            var response = new ResponseDto<ConsolidadoModuleDto>()
            {
                Status = 1,
                Message = "mostrando Data",
                Data = resultado
            };
            this._logger.LogInformation($"ResportConsolidadoController/Index() => RESPONSE: /n {JsonConvert.SerializeObject(response, Formatting.Indented)} ");
            return response;
        }
        [HttpGet("report-empresa")]
        public  FileStreamResult ViewReport()
        {
            return  this._consolidadosReportsModule.ReportePorEmpresa();
        }
        [HttpGet("report-empresa-base64")]
        public byte[] ViewReportBase64()
        {
            return this._consolidadosReportsModule.ReportePorEmpresaBase64();
        }
    }
}
using BlazorAptit.Models.Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BlazorAptit.Models;

namespace BlazorAptit.Controllers
{
    [Route("[controller]")]
    public class JobController : ControllerBase
    {


        public IOctRepository _octRepository { get; set; }
        private readonly ILogger _loggerFactory;

        public JobController(IOctRepository jobRepository, ILoggerFactory loggerFactory)
        {
            this._octRepository = jobRepository;
            this._loggerFactory = loggerFactory.CreateLogger(nameof(JobController));
        }
        [HttpGet("GetUserList")]
        public async Task<object> GetUserList()
        {
            try
            {
                var data = await _octRepository.GetUserList();
                return Ok(data);
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError(exp.Message);
                return BadRequest();
            }
        }

        [HttpGet("GetEnterList")]
        public async Task<object> GetEnterList()
        {
            try
            {
                var data = await _octRepository.GetEnterList();
                return Ok(data);
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError(exp.Message);
                return BadRequest();
            }
        }

        [HttpGet("GetUserResultList")]
        public async Task<object> GetUserResultList()
        {
            try
            {
                var data = await _octRepository.GetUserResultList();
                return Ok(data);
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError(exp.Message);
                return BadRequest();
            }
        }

        [HttpGet("GetEnterResultUserList/{ins_seq}/{tur_seq}")]
        public async Task<object> GetEnterResultUserList(string ins_seq, string tur_seq)
        {
            try
            {
                var data = await _octRepository.GetEnterResultUserList(ins_seq, tur_seq);
                return Ok(data);
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError(exp.Message);
                return BadRequest();
            }
        }

        [HttpGet("GetUserInfo/{ac_id}")]
        public async Task<object> GetUserInfo(string ac_id)
        {
            try
            {
                var data = await _octRepository.GetUserInfo(ac_id);
                return Ok(data);
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError(exp.Message);
                return BadRequest();
            }
        }

        [HttpGet("GetEnterInfo/{ins_seq}")]
        public async Task<object> GetEnterInfo(string ins_seq)
        {
            try
            {
                var data = await _octRepository.GetEnterInfo(ins_seq);
                return Ok(data);
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError(exp.Message);
                return BadRequest();
            }
        }

        [HttpGet("GetUserListDetail/{pe_seq}")]
        public async Task<object> GetUserListDetail(string pe_seq)
        {
            try
            {
                var data = await _octRepository.GetUserListDetail(pe_seq);
                return Ok(data);
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError(exp.Message);
                return BadRequest();
            }
        }
        [HttpGet("GetQuestionExplain")]
        public async Task<object> GetQuestionExplain()
        {
            try
            {
                var data = await _octRepository.GetQuestionExplain();
                return Ok(data);
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError(exp.Message);
                return BadRequest();
            }
        }
        [HttpGet("GetJobList")]
        public async Task<object> GetJobList()
        {
            try
            {
                var data = await _octRepository.GetJobList();
                return Ok(data);
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError(exp.Message);
                return BadRequest();
            }
        }
        [HttpGet("GetMajorList")]
        public async Task<object> GetMajorList()
        {
            try
            {
                var data = await _octRepository.GetMajorList();
                return Ok(data);
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError(exp.Message);
                return BadRequest();
            }
        }

        [HttpGet("GetQuestionData")]
        public async Task<object> GetQuestionData()
        {
            try
            {
                var data = await _octRepository.selectQuestionData();
                return Ok(data);
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError(exp.Message);
                return BadRequest();
            }
        }

        [HttpGet("GetDutyList")]
        public async Task<object> GetDutyList()
        {
            try
            {
                var data = await _octRepository.GetDutyList();
                return Ok(data);
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError(exp.Message);
                return BadRequest();
            }
        }
        [HttpGet("GetCommonCode")]
        public async Task<object> GetCommonCode()
        {
            try
            {
                var data = await _octRepository.GetCommonCode();
                return Ok(data);
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError(exp.Message);
                return BadRequest();
            }
        }

        [HttpPost("Update/Job")]
        public async Task<object> updateJob([FromBody] JobUpdateModel model)
        {
            try
            {
                var data = await _octRepository.updateJob(model);
                return Ok(data);
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError(exp.Message);
                return BadRequest();
            }
        }
        [HttpPost("Update/Major")]
        public async Task<object> updateMajor([FromBody] MajorionUpdateModel model)
        {
            try
            {
                var data = await _octRepository.updateMajor(model);
                return Ok(data);
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError(exp.Message);
                return BadRequest();
            }
        }
        [HttpPost("Update/Duty")]
        public async Task<object> updateDuty([FromBody] DutyUpdateModel model)
        {
            try
            {
                var data = await _octRepository.updateDuty(model);
                return Ok(data);
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError(exp.Message);
                return BadRequest();
            }
        }
        [HttpPost("Update/Question")]
        public async Task<object> updateQuestion([FromBody] QuestionUpdateModel model)
        {
            try
            {
                var data = await _octRepository.updateQuestion(model);
                return Ok(data);
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError(exp.Message);
                return BadRequest();
            }
        }
        [HttpPost("Update/QuestionData")]
        public async Task<object> updateQuestionData([FromBody] QuestionUpdateDataModel model)
        {
            try
            {
                var data = await _octRepository.updateQuestionData(model);
                return Ok(data);
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError(exp.Message);
                return BadRequest();
            }
        }

    }
} 
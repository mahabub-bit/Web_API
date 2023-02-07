using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_01.Models;
using Project_01.Models.Dto;
using Project_01.Repository.IRepository;
using System.Net;

namespace Project_01.Controllers
{
    [Route("api/CategoryTypeAPI")]
    [ApiController]
    public class CategoryTypeAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ICompanyRepository _dbCompany;
        private readonly ICategoryTypeRepository _dbCategoryType;
        private readonly IMapper _mapper;

        public CategoryTypeAPIController(ICompanyRepository dbCompany, IMapper mapper, ICategoryTypeRepository dbCategoryType)
        {
            _dbCategoryType = dbCategoryType;
            _dbCompany = dbCompany;
            _mapper = mapper;
            this._response = new();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetCategorytype()
        {
            try
            {
                IEnumerable<CategoryType> categoryTypeList = await _dbCategoryType.GetAllAsync(includeProperties: "Company");
                _response.Result = _mapper.Map<List<CategoryTypeDTO>>(categoryTypeList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetCategoryType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> GetCategoryType(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var categoryType = await _dbCategoryType.GetAsync(u => u.Id == id);
                if (categoryType == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<CategoryTypeDTO>(categoryType);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateCategoryType([FromBody] CategoryTypeCreateDTO createDTO)
        {
            try
            {
                if (await _dbCategoryType.GetAsync(u => u.Id == createDTO.CategoryId) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Category ID already Exists!");
                    return BadRequest(ModelState);
                }

                if (await _dbCompany.GetAsync(u => u.Id == createDTO.CompanyId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Company ID is Invalid !");
                    return BadRequest(ModelState);
                }

                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                CategoryType categoryType = _mapper.Map<CategoryType>(createDTO);


                await _dbCategoryType.CreateAsync(categoryType);
                _response.Result = _mapper.Map<CategoryTypeDTO>(categoryType);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetCategoryType", new { id = categoryType.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteCategoryType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteCategoryType(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var categoryType = await _dbCategoryType.GetAsync(u => u.Id == id);
                if (categoryType == null)
                {
                    return NotFound();
                }
                await _dbCategoryType.RemoveAsync(categoryType);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdateCategoryType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateCategoryType(int id, [FromBody] CategoryTypeUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }

                if (await _dbCompany.GetAsync(u => u.Id == updateDTO.CompanyId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Company ID is Invalid !");
                    return BadRequest(ModelState);
                }


                CategoryType model = _mapper.Map<CategoryType>(updateDTO);


                await _dbCategoryType.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }



    }
}

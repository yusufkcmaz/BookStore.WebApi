using AutoMapper;
using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.ApiWriterDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private readonly IWriterService _writerService;
        private readonly IMapper _mapper;   

        public WriterController(IWriterService writerService, IMapper mapper)
        {
            _writerService = writerService;
            _mapper = mapper;

        }

        [HttpGet("AllWriter")]
        public IActionResult GetAllWriter()
        {
            var values = _writerService.GetAllWriter();
            return Ok(values);
        }





        [HttpGet]
        public IActionResult WriterList()
        {
            var values = _writerService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult WriterCreate(CreateWriterDto writerDto)

        {
            var write = _mapper.Map<Writer>(writerDto);
            _writerService.TAdd(write);
            return Ok("Ekleme Başarılı");
            //_writerService.TAdd(writer);
            //return Ok("Yazar Eklendi");
        }

        [HttpDelete]

        public IActionResult DeleteWriter(int id)
        {
            _writerService.TDelete(id);
            return Ok("Yazar Silindi");

        }

        [HttpPut]

        public IActionResult UpdateWriter(UpdateWriterDto writerDto)
        {
            var write = _mapper.Map<Writer>(writerDto);
            _writerService.TUpdate(write);
            return Ok("Düzenleme başarılı");
            //_writerService.TUpdate(writer);
            //return Ok("Güncelleme Başarılı");

        }


       
    }
}

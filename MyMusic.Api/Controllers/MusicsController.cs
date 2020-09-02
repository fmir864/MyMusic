using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyMusic.Api.Resources;
using MyMusic.Core.Models;
using MyMusic.Core.Services;

[Route("api/[controller]")]
[ApiController]
public class MusicsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMusicService _musicService;

    public MusicsController(IMusicService musicService, IMapper mapper)
    {
        this._mapper = mapper;
        this._musicService = musicService;
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<MusicResource>>> GetAllMusics()
    {
        var musics = await _musicService.GetAllWithArtist();
        var musicResources = _mapper.Map<IEnumerable<Music>, IEnumerable<MusicResource>>(musics);

        return Ok(musicResources);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MusicResource>> GetMusicById(int id)
    {
        var music = await _musicService.GetMusicById(id);
        var musicResource = _mapper.Map<Music, MusicResource>(music);

        return Ok(musicResource);
    }
}
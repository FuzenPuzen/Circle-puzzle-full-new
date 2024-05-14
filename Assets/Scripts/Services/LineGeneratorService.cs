using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LineGeneratorService : IService
{
	[Inject] private IServiceFabric _serviceFabric;
    [Inject] private IDifficultyService _difficultyService;
    [Inject] private IPicturesDataManager _picturesDataManager;
	private CirclesSOData _circlesSOData;
    private Dictionary<int, Sprite> _lines;
    private List<LineViewService> _lineViewServices = new();

    public void ActivateService()
	{
        _circlesSOData = _difficultyService.GetCurrentCircleData();
        _lines = _circlesSOData.GetLinesData();
        SpawnLines();
    }

    private void SpawnLines()
    {
        for (int i = 0; i < _lines.Count; i++)
        {  
            var lineViewService = _serviceFabric.InitMultiple<LineViewService>();
            lineViewService.ActivateService();
            lineViewService.SetLineData(CreateLineData(i));
            _lineViewServices.Add(lineViewService);
        }
    }

    private LineData CreateLineData(int i)
    {
        LineData lineData = new LineData();
        lineData.StartRotation = Random.Range(0, 360);
        lineData.MaskImage = _lines.GetValueOrDefault(i);
        lineData.PictireImage = _picturesDataManager.GetCurrentPicture();
        return lineData;
    }

    public List<LineViewService> GetLineViewServices() => _lineViewServices;
}

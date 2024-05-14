using EventBus;

public struct ScoreChanged : IEvent { public int score; }
public struct RecordChanged : IEvent { public int record; }
public struct OnRestart : IEvent { }
public struct OnRestartButton : IEvent { }
public struct OnLineLocked : IEvent { }
public struct OnMute : IEvent { }
public struct OnUnMute : IEvent { }
public struct OnEndRotate : IEvent { }
public struct OnIncreaceX : IEvent { }
public struct OnDecreaceX : IEvent { }
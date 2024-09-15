using RpgCalendar.Utilities.Enums;

namespace RpgCalendar.WebService;

public record ErrorApiModel(ErrorsEnums.ErrorCode ErrorCode, string ErrorMessage);

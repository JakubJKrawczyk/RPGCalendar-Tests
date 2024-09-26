// ReSharper disable InconsistentNaming
namespace RpgCalendar.Utilities;

public static class Consts
{
    public const string DefaultPassword = "qwerty";
    public const string DefaultEmail = "test@test.com";
    public static string EmailDomain => "rpgcalendar.pl";

    public static class Messages
    {
        public const string USER_NOR_REGISTERED = "The user is not registered.";
        public const string USER_ALREADY_REGISTERED = "The user is already registered.";
        public const string INVALID_TIME_RANGE = "Provided time range is negative.";
        public const string TITLE_AND_DESCRIPTION_MISMATCH = "Title and description must be provided both or not provided at all.";
        public const string NO_CHANGES_REQUESTED = "Patch changes nothing.";
        public const string CANNOT_CHANGE_EVENT_TYPE = "Patch cannot remove or add title or description.";
        public const string PATCH_INVALID_TIME_RANGE = "Patch change leads to invalid time range.";
        public const string IMAGE_NOT_EXISTS = "Chosen image found in storage.";
        public const string USER_NOT_EXISTS = "User not exists.";
        public const string USER_ALREADY_IN_GROUP = "User is already in group.";
        public const string INVITE_NOT_EXISTS  = "Invite not exists.";
        public const string CANNOT_REMOVE_OWNER = "Cannot remove owner from it's group.";
        public const string MEMBER_NOT_IN_GROUP = "Member already not in group.";
        public const string CANNOT_SET_OWNER_PERMISSION = "This endpoint cannot be used to set owner permission.";
        public const string CANNOT_CHANGE_OWNER_PERMISSION = "Cannot remove owner permission from it's group.";
        public const string OWNER_GROUP_LIMIT_REACHED = "Owned groups limit reached.";
        public const string MEMBERS_LIMIT_REACHED = "Members limit reached.";
        public const string GROUP_NOT_EXISTS = "Group not exists.";
    }
}
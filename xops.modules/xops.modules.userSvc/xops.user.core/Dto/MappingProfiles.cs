using System;
using xops.user.core.Entities;

namespace xops.user.core.Dto;

public static class MappingProfiles
{

    public static UserDto toUserDto(this User user)
    {
        return new UserDto()
        {
            Name = user.Name,
            UserName = user.UserName,
            Email = user.Email,
            Image = user.Image,
            Id = user.Id,
        };
    }


    public static User toUser(this UserDto userDto)
    {
        return new User()
        {
            Name = userDto.Name,
            Image = userDto.Image,
            Email = userDto.Email,
            UserName = userDto.UserName,
        };
    }





}

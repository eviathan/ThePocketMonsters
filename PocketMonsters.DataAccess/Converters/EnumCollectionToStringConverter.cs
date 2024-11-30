using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

public class EnumCollectionToStringConverter<TEnum> : ValueConverter<ICollection<TEnum>, string>
    where TEnum : Enum
{
    public EnumCollectionToStringConverter()
        : base(
            v => JsonConvert.SerializeObject(v.Select(e => e.ToString()).ToList()),
            v => JsonConvert.DeserializeObject<ICollection<string>>(v)
                    .Select(e => (TEnum)Enum.Parse(typeof(TEnum), e))
                    .ToList())
    {
    }
}
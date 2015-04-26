
namespace SAB.XmlPageParser
{
	public enum ExecutionStep
	{
		Select = 0,
		Insert = 1,
		Update = 2,
		Delete = 3
	}

	public enum ContentType
	{
		FullXml,
		FullHtml,
		Json,
		RawXml
	}
}

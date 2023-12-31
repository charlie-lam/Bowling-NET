using AutoFixture.Xunit2;
using AutoFixture.AutoNSubstitute;

namespace TestHelpers.AutoSubstituteData;

public class AutoSubstituteData : AutoDataAttribute
   {
       public AutoSubstituteData() 
           : base(() => new Fixture().Customize(new AutoNSubstituteCustomization()))
       {
       }
   }
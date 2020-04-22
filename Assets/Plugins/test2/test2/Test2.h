#ifdef TEST2_EXPORT
#define TEST2_API __declspec(dllexport) 
#else
#define TEST2_API __declspec(dllimport) 
#endif

extern "C" 
{
    TEST2_API float TestMultiply(float a, float b);
    TEST2_API float TestDivide(float a, float b);
}
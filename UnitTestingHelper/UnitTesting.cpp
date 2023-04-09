#include "pch.h"

#include "UnitTesting.h"
#include <iostream>

using namespace UnitTestingHelper;

void UnitTesting::printDemo(System::Action<System::String^>^ callback)
{
	std::cout << "sucessfull to call CLR Class library Function UnitTesting.printDemo " << std::endl;

	auto str = gcnew System::String("sucessfull to call CLR Class library Function UnitTesting.printDemo ������هBIMBASE SDK��");

	callback->Invoke(str);
}
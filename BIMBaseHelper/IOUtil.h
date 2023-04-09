#pragma once
#include"stdafx.h"

using namespace Host;

namespace BIMBaseHelper {


	public ref class IOUtil
	{
	public:
		static void pickPoint(System::Action<Host::Ge::Point3d^>^ callback);

		static void exitPickPointMode();
	};

}
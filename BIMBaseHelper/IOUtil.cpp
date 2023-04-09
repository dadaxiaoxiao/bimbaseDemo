#include "IOUtil.h"

using namespace BIMBaseHelper;

ref class PointPickData {

public:
	static System::Action<Host::Ge::Point3d^>^ s_callback;
};


class PointPickTool : public BPPrimitiveTool
{
private:
	constexpr static const wchar_t* const PROMPT = L"请选取一个点";
public:
	constexpr static const wchar_t* const NAME = L"PICKPOINT6380A400-2EA4-4C44-850C-A4BB0E084256";

public:
	PointPickTool() {

	}

	virtual void _onPostInstall() override {
		BPPrimitiveTool::_onPostInstall();
		//打开捕捉
		BPSnap::getInstance().enableLocate(false);
		BPSnap::getInstance().enableSnap(true);
	}

	virtual void _onRestartTool() override
	{

	}

	virtual bool _onResetButton(BPBaseButtonEventCP ev) override {
		_exitTool();
		return true;
	}

	virtual bool _onDataButton(BPBaseButtonEventCP ev) override
	{
		auto pt = const_cast<GePoint3d*>(ev->getPoint());
		auto pt2 = gcnew Host::Ge::Point3d(pt->x, pt->y, pt->z);
		PointPickData::s_callback->Invoke(pt2);
		//System::IntPtr pvFun1 = System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(safe_cast<System::Func<Host::Ge::Point3d^>^>(IOUtil::s_callback));
		_exitTool();
		return true;
	}
};

BPTool* CreatePointPickTool()
{
	PointPickTool* tool = new PointPickTool();
	auto id = tool->getToolId();
	tool->setToolId(PointPickTool::NAME);
	auto id2 = tool->getToolId();
	return tool;
}

AutoDoRegisterFunctionsBegin
BPToolsManager::registerTool(PointPickTool::NAME, &CreatePointPickTool);
AutoDoRegisterFunctionsEnd

void IOUtil::pickPoint(System::Action<Host::Ge::Point3d^>^ callback)
{
	IOUtil::exitPickPointMode();
	PointPickData::s_callback = callback;
	BPUserInputManager::exeCommand(PointPickTool::NAME);
	// TODO: 在此处插入 return 语句
}

void IOUtil::exitPickPointMode()
{
	auto pTool = BPPrimitiveTool::getActivePrimitiveTool();
	if (nullptr != pTool) {
		//auto& id = pTool->getToolId();
		//if (id.equals(PointPickTool::NAME)) {
		//	pTool->callExitTool();
		//}
		if (dynamic_cast<PointPickTool*>(pTool)) {
			pTool->callExitTool();
		}
	}
}


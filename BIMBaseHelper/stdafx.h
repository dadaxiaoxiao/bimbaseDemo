// stdafx.h : 标准系统包含文件的包含文件，
// 或是经常使用但不常更改的
// 特定于项目的包含文件

#pragma once

#ifndef VC_EXTRALEAN
#define VC_EXTRALEAN            // 从 Windows 头中排除极少使用的资料
#endif



#define _ATL_CSTRING_EXPLICIT_CONSTRUCTORS      // 某些 CString 构造函数将是显式的

#include <afxwin.h>         // MFC 核心组件和标准组件
#include <afxext.h>         // MFC 扩展

#ifndef _AFX_NO_OLE_SUPPORT
#include <afxole.h>         // MFC OLE 类
#include <afxodlgs.h>       // MFC OLE 对话框类
#include <afxdisp.h>        // MFC 自动化类
#endif // _AFX_NO_OLE_SUPPORT

#ifndef _AFX_NO_DB_SUPPORT
#include <afxdb.h>                      // MFC ODBC 数据库类
#endif // _AFX_NO_DB_SUPPORT

#ifndef _AFX_NO_DAO_SUPPORT
#include <afxdao.h>                     // MFC DAO 数据库类
#endif // _AFX_NO_DAO_SUPPORT

#ifndef _AFX_NO_OLE_SUPPORT
#include <afxdtctl.h>           // MFC 对 Internet Explorer 4 公共控件的支持
#endif
#ifndef _AFX_NO_AFXCMN_SUPPORT
#include <afxcmn.h>                     // MFC 对 Windows 公共控件的支持
#endif // _AFX_NO_AFXCMN_SUPPORT

#include <afxcontrolbars.h>     // 功能区和控件条的 MFC 支持

#include "BcgFrame/BCGCBProInc.h"
#include <boost/integer.hpp>
#include <boost/integer_fwd.hpp>
#include <boost/bimap.hpp>

//////////////////////////////////////////////////////////////////////////
//0

#include <vector>
#include <map>
#include <algorithm>
#ifndef PI
#define PI ((double)3.1415926535897932)
#endif
using namespace std;

// 1. 图形平台基础数据头文件
#include "BPExportMacros.h"
#include "PKPMExportMacros.h"
#include "P3DDC/P3DDCAPI.h"
#include "P3DGeomObject/P3DGeomObjectPublicAPI.h"

#define BRPLATFORM_EXPORT IMPORT_ATTRIBUTE
#define BLUERIVERCORE_EXPORTED IMPORT_ATTRIBUTE


// 2. BIMBase Publish API头文件
#include "JsonCpp/JsonCppAPI.h"
#include "BPBase/BPBaseAPI.h"
#include "BPData/BPDataAPI.h"
#include "BPDataCore/BPDataCoreDef.h"
#include "BPDataCore/BPDataCoreAPI.h"
#include "BPDataCore/BPPlacement.h"
#include "BPDataCore/BPDomainDataInitManager.h"
#include "BPDataCore/BPEntitySymbologyEvent.h"
#include "BPDisplay/BPDisplayAPI.h"
#include "BPInteraction/BPInteractionAPI.h"
#include "BPFrame/BPFrameAPI.h"
#include "BPSolidCore/BPSolidCoreAPI.h"
#include "BPBase/BPPlatformAPI.h"
// 3. 专业平台头文件
//#include "PBPlatform/PBProgressCtrlManager.h"
#include "TgGe/TgGe.h"
#include "PBClashDetection/PBClashDetectionAPI.h"
#include "PBClashDetection/ClashDetection.h"
#include "PBBimCore/PBBimCoreAPI.h"
#include "PBBimCore/PBAxisElement.h"
#include "BPApp/PBBimAppAPI.h"
#include "PBBimCore/PBBimSchemaManager.h"
#include "PBPlatform/PBPlatformAPI.h"
#include "PBBimCore/PBClippingEvent.h"
#include "PBBimUtilities/rapidjson/document.h"
#include "PBBimUtilities/rapidjson/stringbuffer.h"
#include "PBBimUtilities/rapidjson/Writer.h" 
#include "BPUIFrameWork/BPUIFrameWorkAPI.h"
#include "BPUIFrameWork/BPUIFrameWorkUtil.h"
#include "BPUIFrameWork/BPNewDockContainer.h"
#include "BPUIFrameWork/BPNewDockManager.h"
#include "BPUIFrameWork/RButtonClickItem.h"
#include "BPUIFrameWork/BPViewRButtonClickListener.h"
#include "BPUIFrameWork/BPViewRButtonClickListenerCenter.h"

//#include "ProjectTree/ProjectTreeExportDef.h"
//#include "ProjectTree/ProjectTreeInfoManager.h"

#include "BPApp/PBToolSettingManager.h"

#include "PBBimUtilities/PBimsErrExceptionUtil.h"

#include "PBBimTools/PBBimToolsAPI.h"
//#include "BPPrimaryElement/BPHatch.h"
#include "BPPrimaryElement/BPHatchVardef.h"
#include "BPPrimaryElement/BPPrimaryGeomAPI.h"
#include "BPPrimaryElement/BPHatchDefine.h"
#include "BPPrimaryElement/BPHatch.h"
#include "BPPrimaryElement/BPHatchPattern.h"
#include "BPPrimaryElement/BPHatchPatternManager.h"

//2.资源切换头文件
#include "PBBimCore/PBBimExtensionModule.h"
#include "PBBimCore/PBBimCoreAPI.h"
#include "BPUIFrameWork/BPNewDockManager.h"
#include "BPUIFrameWork/BPNewDockContainer.h"

//#include <cereal/types/unordered_map.hpp>
//#include <cereal/types/memory.hpp>
//#include <cereal/types/vector.hpp>
//#include <cereal/types/string.hpp>
//#include <cereal/archives/binary.hpp>
//#include <cereal/archives/json.hpp>
//#include <cereal/cereal.hpp>
//#include "cereal/details/polymorphic_impl.hpp"
//#include <cereal/types/polymorphic.hpp>

#include "cereal/archives/binary.hpp"
#include <cereal/types/unordered_map.hpp>
#include <cereal/types/memory.hpp>
#include <cereal/types/vector.hpp>
#include <cereal/types/string.hpp>
#include <cereal/archives/binary.hpp>
#include <cereal/archives/json.hpp>
#include <cereal/cereal.hpp>
#include <cereal/types/polymorphic.hpp>
//#include "cereal/details/polymorphic_impl.hpp"

//#include "cereal/types/polymorphic.hpp"

#define DefineSuper(B)  public: typedef B T_Super; 
//#define PI 3.1415936

using namespace PBBim;
using namespace PBBim::PBBimCore;
using namespace BIMBase;
using namespace P3DApi::P3DApplication;
using namespace BIMBase::Data;
using namespace BIMBase::Core;
using namespace BIMBase::SolidCore;

//材质
#include"MaterialConfig/BPMaterialEx.h"

//数据交换
#include "DataExchange/DataExchangeAPI.h"

//属性面板相关
#include "Share/Common/WDPublicDef.h"
#include"Share/Common/ExportMacro.h"
#include "WDUi/WDToolProperty.h"

//追踪器相关
#include "Common/SDDef.h"
#include "WDUi/TracerMacros.h"
#include "WDUi/WDTracerCustomFunPool.h"

//施工图相关
//#include "PBBimDrawingCommon/PBBimDrawingCommonDef.h"
//#include "PBBimDrawingCommon/PBimsPSLibAPIUtil.h"
//#include "PBBimDrawingCommon/DrawingPaperLineDim.h"
#include "BPPrimaryElement/BPTextEntity.h"
#pragma comment(lib,"BPSerialCommonLib.lib")

//组件
#pragma comment(lib,"BPParametricData.lib")
#pragma comment(lib,"BPParametricCore.lib")
#pragma comment(lib,"BPParametricBase.lib")
#include "BPParametricData/BPParametricDataAPI.h"
#include "BPParametricCore/BPParametricCoreAPI.h"
#include "BPParametricBase/BPParametricBaseAPI.h"


//示例文件头文件
#include "GIM/PBGimPlatformUtil.h"
#include "GIM/GIMGeBaseModel/GimGeBaseAPI.h"
//PEModel头文件
#include "PE/PEPublicAPI/PECore/PECoreDef.h"
#include "PE/PEPublicAPI/PEModel/PEModelAPI.h"
#include "PE/PEPublicAPI/PEConfig/PEConfigAPI.h"
#include "PE/PEPublicAPI/PELibrary/PEDeviceModelManager.h"




static void serializePoint3DVec(cereal::BinaryOutputArchive& ar, const std::vector<GePoint3d>& pt)
{
	ar(pt.size());
	for (GePoint3d p : pt)
	{
		ar(p.x, p.y, p.z);
	}

}
static void deSerializePoint3DVec(cereal::BinaryInputArchive& ar, std::vector<GePoint3d>& vec)
{

	vec.clear();
	size_t size = 0;
	ar(size);
	for (int i = 0; i < size; i++)
	{
		double x, y, z;
		ar(x, y, z);
		GePoint3d pt = GePoint3d::create(x, y, z);
		vec.push_back(pt);
	}

}
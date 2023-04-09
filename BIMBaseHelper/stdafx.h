// stdafx.h : ��׼ϵͳ�����ļ��İ����ļ���
// ���Ǿ���ʹ�õ��������ĵ�
// �ض�����Ŀ�İ����ļ�

#pragma once

#ifndef VC_EXTRALEAN
#define VC_EXTRALEAN            // �� Windows ͷ���ų�����ʹ�õ�����
#endif



#define _ATL_CSTRING_EXPLICIT_CONSTRUCTORS      // ĳЩ CString ���캯��������ʽ��

#include <afxwin.h>         // MFC ��������ͱ�׼���
#include <afxext.h>         // MFC ��չ

#ifndef _AFX_NO_OLE_SUPPORT
#include <afxole.h>         // MFC OLE ��
#include <afxodlgs.h>       // MFC OLE �Ի�����
#include <afxdisp.h>        // MFC �Զ�����
#endif // _AFX_NO_OLE_SUPPORT

#ifndef _AFX_NO_DB_SUPPORT
#include <afxdb.h>                      // MFC ODBC ���ݿ���
#endif // _AFX_NO_DB_SUPPORT

#ifndef _AFX_NO_DAO_SUPPORT
#include <afxdao.h>                     // MFC DAO ���ݿ���
#endif // _AFX_NO_DAO_SUPPORT

#ifndef _AFX_NO_OLE_SUPPORT
#include <afxdtctl.h>           // MFC �� Internet Explorer 4 �����ؼ���֧��
#endif
#ifndef _AFX_NO_AFXCMN_SUPPORT
#include <afxcmn.h>                     // MFC �� Windows �����ؼ���֧��
#endif // _AFX_NO_AFXCMN_SUPPORT

#include <afxcontrolbars.h>     // �������Ϳؼ����� MFC ֧��

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

// 1. ͼ��ƽ̨��������ͷ�ļ�
#include "BPExportMacros.h"
#include "PKPMExportMacros.h"
#include "P3DDC/P3DDCAPI.h"
#include "P3DGeomObject/P3DGeomObjectPublicAPI.h"

#define BRPLATFORM_EXPORT IMPORT_ATTRIBUTE
#define BLUERIVERCORE_EXPORTED IMPORT_ATTRIBUTE


// 2. BIMBase Publish APIͷ�ļ�
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
// 3. רҵƽ̨ͷ�ļ�
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

//2.��Դ�л�ͷ�ļ�
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

//����
#include"MaterialConfig/BPMaterialEx.h"

//���ݽ���
#include "DataExchange/DataExchangeAPI.h"

//����������
#include "Share/Common/WDPublicDef.h"
#include"Share/Common/ExportMacro.h"
#include "WDUi/WDToolProperty.h"

//׷�������
#include "Common/SDDef.h"
#include "WDUi/TracerMacros.h"
#include "WDUi/WDTracerCustomFunPool.h"

//ʩ��ͼ���
//#include "PBBimDrawingCommon/PBBimDrawingCommonDef.h"
//#include "PBBimDrawingCommon/PBimsPSLibAPIUtil.h"
//#include "PBBimDrawingCommon/DrawingPaperLineDim.h"
#include "BPPrimaryElement/BPTextEntity.h"
#pragma comment(lib,"BPSerialCommonLib.lib")

//���
#pragma comment(lib,"BPParametricData.lib")
#pragma comment(lib,"BPParametricCore.lib")
#pragma comment(lib,"BPParametricBase.lib")
#include "BPParametricData/BPParametricDataAPI.h"
#include "BPParametricCore/BPParametricCoreAPI.h"
#include "BPParametricBase/BPParametricBaseAPI.h"


//ʾ���ļ�ͷ�ļ�
#include "GIM/PBGimPlatformUtil.h"
#include "GIM/GIMGeBaseModel/GimGeBaseAPI.h"
//PEModelͷ�ļ�
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
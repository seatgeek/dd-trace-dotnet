#pragma once
#include <string>

#include "environment_variables.h"
#include "logging.h"

namespace trace {

  WSTRING env_vars_to_display[]{
    environment::tracing_enabled,
    environment::debug_enabled,
    environment::profiler_home_path,
    environment::integrations_path,
    environment::include_process_names,
    environment::exclude_process_names,
    environment::agent_host,
    environment::agent_port,
    environment::env,
    environment::service_name,
    environment::service_version,
    environment::disabled_integrations,
    environment::clr_disable_optimizations,
    environment::domain_neutral_instrumentation,
    environment::azure_app_services,
    environment::azure_app_services_app_pool_id,
    environment::azure_app_services_cli_telemetry_profile_value};

  WSTRING skip_assembly_prefixes[]{
    "Datadog.Trace"_W,
    "MessagePack"_W,
    "Microsoft.AI"_W,
    "Microsoft.ApplicationInsights"_W,
    "Microsoft.Build"_W,
    "Microsoft.CSharp"_W,
    "Microsoft.Extensions"_W,
    "Microsoft.Web.Compilation.Snapshots"_W,
    "Sigil"_W,
    "System.Core"_W,
    "System.Console"_W,
    "System.Collections"_W,
    "System.ComponentModel"_W,
    "System.Diagnostics"_W,
    "System.Drawing"_W,
    "System.EnterpriseServices"_W,
    "System.IO"_W,
    "System.Runtime"_W,
    "System.Text"_W,
    "System.Threading"_W,
    "System.Xml"_W,
    "Newtonsoft"_W,};

  WSTRING skip_assemblies[]{
      "mscorlib"_W,
      "netstandard"_W,
      "System.Configuration"_W,
      "Microsoft.AspNetCore.Razor.Language"_W,
      "Microsoft.AspNetCore.Mvc.RazorPages"_W,
      "Anonymously Hosted DynamicMethods Assembly"_W,
      "ISymWrapper"_W};

  WSTRING managed_profiler_full_assembly_version = "Datadog.Trace.ClrProfiler.Managed, Version=1.19.1.0, Culture=neutral, PublicKeyToken=def86d061d0d2eeb"_W;

  WSTRING managed_profiler_calltarget_type = "Datadog.Trace.ClrProfiler.CallTarget.CallTargetInvoker"_W;
  WSTRING managed_profiler_calltarget_beginmethod_name = "BeginMethod"_W;
  WSTRING managed_profiler_calltarget_endmethod_name = "EndMethod"_W;
  WSTRING managed_profiler_calltarget_logexception_name = "LogException"_W;

  WSTRING managed_profiler_calltarget_statetype = "Datadog.Trace.ClrProfiler.CallTarget.CallTargetState"_W;
  WSTRING managed_profiler_calltarget_statetype_shouldrethrowonexception_name = "ShouldRethrowOnException"_W;
  WSTRING managed_profiler_calltarget_statetype_shouldexecutemethod_name = "ShouldExecuteMethod"_W;
  WSTRING managed_profiler_calltarget_statetype_getdefault_name = "GetDefault"_W;

  COR_SIGNATURE ShouldRethrowOnExceptionSig[] = {
      IMAGE_CEE_CS_CALLCONV_DEFAULT | 
          IMAGE_CEE_CS_CALLCONV_DEFAULT_HASTHIS,  // instance call
      0x00,                                       // 0 parameters
      ELEMENT_TYPE_BOOLEAN                        // bool return type
  };

  COR_SIGNATURE ShouldExecuteMethodSig[] = {
      IMAGE_CEE_CS_CALLCONV_DEFAULT |
          IMAGE_CEE_CS_CALLCONV_DEFAULT_HASTHIS,  // instance call
      0x00,                                       // 0 parameters
      ELEMENT_TYPE_BOOLEAN                        // bool return type
  };

  }  // namespace trace

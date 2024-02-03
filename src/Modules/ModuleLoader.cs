﻿using QualityCompany.Service;
using System.Collections;
using UnityEngine;

namespace QualityCompany.Modules;

internal class ModuleLoader : MonoBehaviour
{
    public static ModuleLoader Instance { get; private set; }

    private readonly ACLogger _logger = new(nameof(ModuleLoader));

    private void Start()
    {
        _logger.LogMessage("Start");
        Instance = this;

        transform.position = Vector3.zero;
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one;

        StartCoroutine(LoadScrapValueUIModulesCoroutine());
    }

    private IEnumerator LoadScrapValueUIModulesCoroutine()
    {
        _logger.LogMessage("LoadScrapValueUIModulesCoroutine -> waiting...");
        yield return new WaitForSeconds(2.0f);
        _logger.LogMessage("LoadScrapValueUIModulesCoroutine -> done!");

        // scrap value item ui
        HUDExtensionModule.Spawn();
    }
}

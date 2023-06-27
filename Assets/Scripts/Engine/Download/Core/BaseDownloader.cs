using System;
using System.Collections;
using UnityEngine.Networking;

namespace LinkGo.Common.Download
{
    public abstract class BaseDownloader
    {
        protected UnityWebRequest m_webRequest;

        /// <summary>
        /// ���ص�ַ
        /// </summary>
        public string Url { get; protected set; }

        /// <summary>
        /// ���ؽ���
        /// </summary>
        public float Progress { get; protected set; }

        /// <summary>
        /// �����ٶ�
        /// </summary>
        public float Speed { get; protected set; }

        /// <summary>
        /// �����ַ
        /// </summary>
        public string SavePath { get; protected set; }

        /// <summary>
        /// ����״̬
        /// </summary>
        public DownloadState State { get; protected set; }

        abstract public void Start();

        abstract public bool Update();

        abstract public void Stop();
    }
}

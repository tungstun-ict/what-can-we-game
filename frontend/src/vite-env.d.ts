/// <reference types="vite/client" />

interface ImportMetaEnv {
  readonly VITE_STEAM_KEY: string;
  readonly VITE_STEAM_URL: string;
  readonly VITE_STEAM_FORMAT: string;
  // more env variables...
}

interface ImportMeta {
  readonly env: ImportMetaEnv;
}

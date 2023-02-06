import axios from "axios";

const client = (() => {
  return axios.create({
    baseURL: import.meta.env.VITE_STEAM_URL
  });
})();

const request = async function (options: any, store?: any) {
  const onSuccess = function (response: any) {
    const {
      data: { message }
    } = response;

    return message;
  };

  const onError = function (error: any) {
    return Promise.reject(error.response);
  };

  return client(options).then(onSuccess).catch(onError);
}

export default request;
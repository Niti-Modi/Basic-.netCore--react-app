import axios from "axios";

//contains all the api calls
const baseUrl = "http://localhost:65127/api/";

export default {
  dCandidate(url = baseUrl + "dcandidate/") {
    return {
      fetchAll: () => axios.get(url),
      fetchById: (id) => axios.get(url + id),
      create: (newRecord) => axios.post(url, newRecord),
      update: (id, updateRecord) => axios.put(url + id, updateRecord),
      delete: (id) => axios.delete(url + id),
    };
  },
};

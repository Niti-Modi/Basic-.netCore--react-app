import React, { useState } from "react";

const useForm = (initialFieldValues, validate, setCurrentId) => {
  const [values, setValues] = useState(initialFieldValues);
  const [errors, setErrors] = useState({});

  //handle change function
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    const fieldValue = { [name]: value };

    setValues({
      ...values,
      [name]: value,
    });

    validate(fieldValue);
    //console.log(values);
  };

  const resetForm = () => {
    setValues({
      ...initialFieldValues,
    });
    setErrors({});
    setCurrentId(0);
  };
  return { values, setValues, errors, setErrors, handleInputChange, resetForm };
};

export default useForm;

import React, { useRef, useState } from 'react';
import styled from 'styled-components';

import packageJson from '../../../package.json';

import { EmailEditor } from '../../utils/EmailEditor';
import { EditorRef } from '../../utils/types';
// import EmailEditor from 'react-email-editor';
import sample from './sample.json';
import { useNavigate, useSearchParams } from 'react-router-dom';

const Container = styled.div`
  display: flex;
  flex-direction: column;
  position: relative;
  height: 100%;
`;

const Bar = styled.div`
  flex: 1;
  background-color: #61dafb;
  color: #000;
  padding: 10px;
  display: flex;
  max-height: 40px;

  h1 {
    flex: 1;
    font-size: 16px;
    text-align: left;
  }

  button {
    flex: 1;
    padding: 10px;
    margin-left: 10px;
    font-size: 14px;
    font-weight: bold;
    background-color: #000;
    color: #fff;
    border: 0px;
    max-width: 150px;
    cursor: pointer;
  }
`;

const Example = () => {
  const emailEditorRef = useRef<EditorRef | null>(null);
  const [preview, setPreview] = useState(false);
  const navigate = useNavigate();
  const [searchParams, setSearchParams] = useSearchParams();

  function fnGetIdTemplate() {
    return searchParams.get("idTemplate");
  }
  const saveDesign = () => {
    emailEditorRef.current?.editor?.saveDesign((design) => {
      console.log('saveDesign', design);
      alert('Design JSON has been logged in your developer console.');
      const objectSave = {
        Name: "template email",
        Design: JSON.stringify(design),
        // DesignJson:design,
        DisplayMode: 'email'
      }
      // console.log(JSON.stringify(objectSave))
      const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(objectSave)
      };
      fetch('http://localhost:5001/Email/saveDesign', requestOptions)
        .then(response => response.json())
      // .then(data => this.setState({ postId: data.id }));
    });
  };

  const exportHtml = () => {
    emailEditorRef.current?.editor?.exportHtml((data) => {
      // const { design, html } = data;
      const { html } = data;
      console.log('exportHtml', html);
      alert('Output HTML has been logged in your developer console.');
    });
  };

  const togglePreview = () => {
    if (preview) {
      emailEditorRef.current?.editor?.hidePreview();
      setPreview(false);
    } else {
      emailEditorRef.current?.editor?.showPreview('desktop');
      setPreview(true);
    }
  };

  const onDesignLoad = (data: any) => {
    console.log('onDesignLoad', data);
  };

  const onLoad = () => {
    console.log('onLoad');

    emailEditorRef.current?.editor?.addEventListener(
      'design:loaded',
      onDesignLoad
    );
    const idTemplate = fnGetIdTemplate() ?? "78E6D8B2-3993-440D-A5C4-DAF21017A7CF";
    console.log(idTemplate)
    // fetch('http://localhost:5001/Email/template-mail/6399E249-6DF5-4FB7-9504-C72B28125DD5')
    fetch(`http://localhost:5001/Email/template-mail/${idTemplate}`)
      .then(response => response.json())
      .then(req => {
        const dataJson = req.data;
        const sameple1 = JSON.parse(dataJson.design);
        console.log(sameple1)
        emailEditorRef.current?.editor?.loadDesign(sameple1);
      });

    // emailEditorRef.current?.editor?.loadDesign(sample);
  };

  const onReady = () => {
    console.log('onReady');
  };

  return (
    <Container>
      <Bar>
        <h1>{packageJson.name} v{packageJson.version}</h1>

        <button onClick={() => navigate(`/dashboard`)}>
          Dashboard
        </button>
        <button onClick={togglePreview}>
          {preview ? 'Hide' : 'Show'} Preview
        </button>
        <button onClick={saveDesign}>Save Design</button>
        <button onClick={exportHtml}>Export HTML</button>
      </Bar>

      <React.StrictMode>
        <EmailEditor ref={emailEditorRef} onLoad={onLoad} onReady={onReady} />
      </React.StrictMode>
    </Container>
  );
};

export default Example;
